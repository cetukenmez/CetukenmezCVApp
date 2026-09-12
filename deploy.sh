#!/usr/bin/env bash
# Publishes the site for the Raspberry Pi (linux-arm64, framework-dependent) and
# swaps it into /var/www/CetukenmezCV, restarting the kestrel-cetukenmezcv systemd service.
#
# Usage (from repo root, Git Bash / WSL / Linux):
#   ./deploy.sh
#
# Requirements: dotnet SDK 10, ssh key access to pi@192.168.1.200:2299, passwordless sudo on the Pi.
set -euo pipefail

PI_HOST="${PI_HOST:-pi@192.168.1.200}"
PI_PORT="${PI_PORT:-2299}"
REMOTE_DIR="/var/www/CetukenmezCV"
SERVICE="kestrel-cetukenmezcv.service"

ROOT="$(cd "$(dirname "$0")" && pwd)"
PROJECT="$ROOT/CetukenmezCVApp/CetukenmezCVApp.csproj"
OUT="$ROOT/.publish"
STAMP="$(date +%Y%m%d-%H%M%S)"

echo ">> Publishing (linux-arm64)…"
rm -rf "$OUT"
dotnet publish "$PROJECT" -c Release -r linux-arm64 --self-contained false -nologo -v q -o "$OUT"

echo ">> Packing…"
tar -C "$OUT" -czf "$ROOT/.publish.tar.gz" .

echo ">> Uploading…"
scp -P "$PI_PORT" "$ROOT/.publish.tar.gz" "$PI_HOST:/tmp/cetukenmezcv-$STAMP.tar.gz"

echo ">> Installing on the Pi…"
ssh -p "$PI_PORT" "$PI_HOST" bash -s <<EOF
set -euo pipefail
NEW="$REMOTE_DIR.new-$STAMP"
BAK="$REMOTE_DIR.bak-$STAMP"
mkdir -p "\$NEW"
tar -C "\$NEW" -xzf "/tmp/cetukenmezcv-$STAMP.tar.gz"
rm -f "/tmp/cetukenmezcv-$STAMP.tar.gz"
sudo systemctl stop $SERVICE
if [ -d "$REMOTE_DIR" ]; then sudo mv "$REMOTE_DIR" "\$BAK"; fi
sudo mv "\$NEW" "$REMOTE_DIR"
sudo chown -R pi:pi "$REMOTE_DIR"
sudo systemctl daemon-reload
sudo systemctl start $SERVICE
sleep 3
sudo systemctl --no-pager --lines=5 status $SERVICE || true
echo "HTTP \$(curl -s -o /dev/null -w '%{http_code}' http://127.0.0.1:5020/)"
# keep only the two most recent backups
ls -dt $REMOTE_DIR.bak-* 2>/dev/null | tail -n +3 | xargs -r sudo rm -rf
EOF

rm -f "$ROOT/.publish.tar.gz"
echo ">> Done."

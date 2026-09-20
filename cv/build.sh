#!/usr/bin/env bash
# Renders cv.html to an A4 PDF with headless Chrome/Edge.
# Usage: ./cv/build.sh   (output: cv/can-erdem-tukenmez-cv.pdf)
set -euo pipefail
DIR="$(cd "$(dirname "$0")" && pwd)"
OUT="$DIR/can-erdem-tukenmez-cv.pdf"
for B in "/c/Program Files/Google/Chrome/Application/chrome.exe" \
         "/c/Program Files (x86)/Microsoft/Edge/Application/msedge.exe" \
         "$(command -v google-chrome || true)" "$(command -v chromium || true)"; do
  [ -n "$B" ] && [ -x "$B" ] && BROWSER="$B" && break
done
: "${BROWSER:?No Chrome/Edge found}"
if command -v cygpath >/dev/null; then SRC="file:///$(cygpath -m "$DIR/cv.html")"; PDF="$(cygpath -w "$OUT")"; else SRC="file://$DIR/cv.html"; PDF="$OUT"; fi
"$BROWSER" --headless=new --disable-gpu --no-pdf-header-footer --virtual-time-budget=8000 \
  --user-data-dir="${TMPDIR:-/tmp}/cv-chrome-profile" --print-to-pdf="$PDF" "$SRC" >/dev/null 2>&1
cp "$OUT" "$DIR/../CetukenmezCVApp/wwwroot/can-erdem-tukenmez-cv.pdf"
ls -la "$OUT"

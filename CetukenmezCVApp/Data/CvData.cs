using CetukenmezCVApp.Models;

namespace CetukenmezCVApp.Data;

/// <summary>
/// Single source of truth for everything rendered on the site.
/// Edit this file to update the CV; no view changes required.
/// </summary>
public static class CvData
{
    public static readonly CvProfile Profile = new(
        Name: "Can Erdem Tükenmez",
        Title: "Software Developer",
        Tagline: ".NET backend & cross-platform mobile developer. I build web apps, APIs and published mobile apps, and I run the servers they live on.",
        Bio: "I'm a software developer from İzmir with 8+ years of experience building web applications and backend systems on the .NET stack, " +
             "from hospital information systems to retail e-commerce backends. On the side, under my personal brand Cordelia Software, I design, build " +
             "and publish cross-platform mobile apps with .NET MAUI, backed by ASP.NET Core APIs that I host and operate myself on Linux.",
        Email: "cetukenmez@gmail.com",
        Location: "Karşıyaka, İzmir, Türkiye",
        BirthYear: 1992,
        CvFile: "28072022cv.pdf",
        SiteUrl: "https://canerdemtukenmez.com.tr",
        BrandName: "Cordelia Software",
        BrandUrl: "https://cordeliasoftware.net/",
        BrandLogo: "/images/projects/cordelia.webp",

        Socials:
        [
            new("LinkedIn", "https://www.linkedin.com/in/can-erdem-tukenmez/", "fa-brands fa-linkedin-in"),
            new("GitHub", "https://github.com/cetukenmez", "fa-brands fa-github"),
            new("Instagram", "https://www.instagram.com/cetukenmez", "fa-brands fa-instagram"),
            new("X", "https://twitter.com/cetukenmez", "fa-brands fa-x-twitter"),
        ],

        Stats:
        [
            new("8+", "Years of experience"),
            new("3", "Published mobile apps"),
            new("5", "European championships"),
            new("1", "European silver medal"),
        ],

        SkillGroups:
        [
            new("Backend", "fa-solid fa-server",
                ["C#", ".NET 10 / ASP.NET Core", "ASP.NET MVC", "Web API / REST", "Entity Framework Core", "ADO.NET", "Object-Oriented Design", "Resilience patterns"]),
            new("Mobile", "fa-solid fa-mobile-screen-button",
                [".NET MAUI", "iOS & Android publishing", "App Store Connect", "Google Play Console", "Push notifications"]),
            new("Database", "fa-solid fa-database",
                ["Oracle PL/SQL", "MySQL", "SQL performance tuning", "Data modelling"]),
            new("Frontend", "fa-solid fa-code",
                ["HTML5", "CSS3", "JavaScript", "jQuery", "Razor Pages & Views", "Responsive design"]),
            new("Ops & Tools", "fa-solid fa-gears",
                ["Linux (Debian)", "systemd", "Apache reverse proxy", "Let's Encrypt", "Git", "Raspberry Pi self-hosting"]),
        ],
        AlsoFamiliar: ["Xamarin", "Angular", "RabbitMQ", "Docker"],

        Experience:
        [
            new(".NET Developer", "Migros Ticaret A.Ş.", "https://www.migros.com.tr/", "July 2022 – Present",
                "Backend developer at Türkiye's leading grocery retailer, building and maintaining .NET Core and MVC services with Oracle PL/SQL on the data side.",
                [".NET Core", "ASP.NET MVC", "PL/SQL", "JavaScript"], IsCurrent: true),
            new(".NET Developer", "Probel Software", null, "Feb 2019 – July 2022",
                "Backend developer on a hospital information management system used across Türkiye. Also built business-intelligence and " +
                "purchasing applications for provincial health directorates.",
                [".NET", "PL/SQL", "Business Intelligence"]),
            new("Freelance Software Developer", "Self-employed", null, "March 2018 – Present",
                "Delivered end-to-end web applications for small businesses on .NET and .NET Core, from database design to deployment.",
                [".NET Core", "MVC", "MySQL"]),
            new("Software Development Intern", "Image Software", null, "March 2018 – June 2018",
                "Worked on hotel management systems as part of the development team.",
                [".NET", "SQL"]),
        ],

        Education:
        [
            new("M.Sc. Software Engineering", "İzmir Kâtip Çelebi University", "2020 – 2021", ["GPA 3.80 / 4.00"]),
            new(".NET Educational Program (300 hours)", "Bilge Adam Academy", "2018",
                ["Certificate of Achievement, score 92", "MOC: Developing ASP.NET MVC 4 Web Applications", "MOC: Programming in HTML5 with JavaScript and CSS3"]),
            new("B.Sc. Mathematics", "Akdeniz University", "2010 – 2017", ["GPA 2.51 / 4.00"]),
            new("Science & Mathematics", "Atakent Anatolian High School", "2006 – 2010", ["GPA 3.56 / 5.00"]),
        ],

        Projects:
        [
            new("Kişi Başı", "Finance", "fa-solid fa-wallet",
                "Split shared expenses with friends",
                "Manage every shared expense with friends on holidays, at home or at events. Kişi Başı works out who owes whom and how much, in real time.",
                "/images/projects/kisibasi.webp", "#3b82f6",
                ["Unlimited groups", "Real-time sync", "Detailed reports"],
                [".NET MAUI", "ASP.NET Core API", "MySQL"],
                [
                    new("apple", "https://apps.apple.com/tr/app/ki%C5%9Fi-ba%C5%9F%C4%B1/id6756876095"),
                    new("google", "https://play.google.com/store/apps/details?id=com.cordeliasoftware.kisibasi.mobile"),
                ]),
            new("SporkoLig", "Sports", "fa-solid fa-trophy",
                "Your own leagues, your own stats",
                "Create football, basketball and volleyball leagues with friends, manage fixtures and keep every match statistic safely in one place.",
                "/images/projects/sporkolig.webp", "#22c55e",
                ["Multiple sports", "Custom leagues & fixtures", "Player statistics"],
                [".NET MAUI", "ASP.NET Core API", "MySQL"],
                [
                    new("apple", "https://apps.apple.com/tr/app/sporkolig/id6759477300"),
                    new("google", "https://play.google.com/store/apps/details?id=com.cordeliasoftware.sportsleague.mobile"),
                ]),
            new("Nöbetçi Eczane Bulucu TR", "Health", "fa-solid fa-briefcase-medical",
                "On-duty pharmacy finder for Türkiye",
                "Instantly find pharmacies on night and holiday duty anywhere in Türkiye. See the nearest one on the map, call with a tap and get directions.",
                "/images/projects/nobetcieczane.webp", "#ef4444",
                ["All provinces & districts", "Nearest pharmacy by location", "One-tap call & directions"],
                [".NET MAUI", "ASP.NET Core API", "Maps"],
                [
                    new("apple", "https://apps.apple.com/tr/app/n%C3%B6bet%C3%A7i-eczane-bulucu-tr/id6808086249"),
                    new("google", "https://play.google.com/store/apps/details?id=com.cordeliasoftware.nobetcieczane"),
                ],
                IsNew: true),
        ],

        Achievements:
        [
            new("28th European Youth Team Championships · Silver Medal", "Under 31 Bridge · Turkey National Team", "Veldhoven, Netherlands", "2022", "/images/secondnl.webp"),
            new("26th European Youth Team Championships", "Under 26 Bridge · Turkey National Team", "Šamorín, Slovakia", "2017", "/images/slovakya.webp"),
            new("13th European Youth Pairs Championships", "Under 26 Bridge · Turkey National Pair", "Liepāja, Latvia", "2016", "/images/samorin.webp"),
            new("25th European Youth Team Championships", "Under 26 Bridge · Turkey National Team", "Tromsø, Norway", "2015", "/images/tromso.webp"),
            new("2nd European Open Team Championships", "Open Pétanque · Turkey National Team", "Göteborg, Sweden", "2011", "/images/goteborg.webp"),
        ],

        References:
        [
            new("Ozhan Gulal", "IT Training Senior Executive", "Yemeksepeti"),
            new("Mahmut Eşitmez", "Software Architect", "Image Software"),
        ]);
}

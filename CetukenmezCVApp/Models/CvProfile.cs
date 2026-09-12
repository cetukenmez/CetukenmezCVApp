namespace CetukenmezCVApp.Models;

public sealed record SocialLink(string Name, string Url, string Icon);

public sealed record Stat(string Value, string Label);

public sealed record SkillGroup(string Name, string Icon, IReadOnlyList<string> Skills);

public sealed record ExperienceItem(
    string Role,
    string Company,
    string? CompanyUrl,
    string Period,
    string Description,
    IReadOnlyList<string> Tags,
    bool IsCurrent = false);

public sealed record EducationItem(
    string Degree,
    string School,
    string Period,
    IReadOnlyList<string> Details);

public sealed record StoreLink(string Store, string Url);

public sealed record ProjectItem(
    string Name,
    string Category,
    string CategoryIcon,
    string Tagline,
    string Description,
    string Logo,
    string Accent,
    IReadOnlyList<string> Features,
    IReadOnlyList<string> Tech,
    IReadOnlyList<StoreLink> Stores,
    bool IsNew = false);

public sealed record AchievementItem(
    string Title,
    string Subtitle,
    string Place,
    string Year,
    string Image);

public sealed record ReferenceItem(string Name, string Title, string Company);

public sealed record CvProfile(
    string Name,
    string Title,
    string Tagline,
    string Bio,
    string Email,
    string Location,
    int BirthYear,
    string CvFile,
    string SiteUrl,
    string BrandName,
    string BrandUrl,
    string BrandLogo,
    IReadOnlyList<SocialLink> Socials,
    IReadOnlyList<Stat> Stats,
    IReadOnlyList<SkillGroup> SkillGroups,
    IReadOnlyList<string> AlsoFamiliar,
    IReadOnlyList<ExperienceItem> Experience,
    IReadOnlyList<EducationItem> Education,
    IReadOnlyList<ProjectItem> Projects,
    IReadOnlyList<AchievementItem> Achievements,
    IReadOnlyList<ReferenceItem> References);

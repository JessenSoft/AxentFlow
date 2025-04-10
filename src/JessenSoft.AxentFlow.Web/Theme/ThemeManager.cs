using MudBlazor;

namespace JessenSoft.AxentFlow.Web.Theme
{
    public class ThemeManager
    {
        public MudTheme AxentFlowTheme { get; } = new MudTheme()
        {
            PaletteDark = new PaletteDark()
            {
                Primary = "#2DBA7D",
                Secondary = "#6BAE85",
                AppbarBackground = "#2DBA7D",
                AppbarText = Colors.Shades.White,
                Background = "#1E1E1E",
                Surface = "#2C2C2C",
                DrawerBackground = "#262626",
                TextPrimary = Colors.Shades.White,
            },
            PaletteLight = new PaletteLight
            {
                Primary = "#2DBA7D",
                Secondary = "#6BAE85",
                AppbarBackground = "#2DBA7D",
                AppbarText = Colors.Shades.White,
                Background = "#F7F9F9",
                Surface = "#FFFFFF",
                DrawerBackground = Colors.Shades.White,
                TextPrimary = "#1F2D2E",
                TextSecondary = "#546E7A",
            },
            LayoutProperties = new LayoutProperties()
            {
                DefaultBorderRadius = "6px"
            }
        };
    }
}

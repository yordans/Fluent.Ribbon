#pragma warning disable

namespace Fluent.Localization.Languages
{
    [RibbonLocalization("Romanian", "ro")]
    public class Romanian : RibbonLocalizationBase
    {
        public override string Automatic { get; } = "Automată";
        public override string BackstageButtonKeyTip { get; } = FallbackLocalization.BackstageButtonKeyTip;
        public override string BackstageButtonText { get; } = "Fișier";
        public override string CustomizeStatusBar { get; } = FallbackLocalization.CustomizeStatusBar;
        public override string DisplayOptionsButtonScreenTipText { get; } = FallbackLocalization.DisplayOptionsButtonScreenTipText;
        public override string DisplayOptionsButtonScreenTipTitle { get; } = FallbackLocalization.DisplayOptionsButtonScreenTipTitle;
        public override string ExpandRibbon { get; } = FallbackLocalization.ExpandRibbon;
        public override string MinimizeRibbon { get; } = FallbackLocalization.MinimizeRibbon;
        public override string MoreColors { get; } = "Mai multe culori...";
        public override string NoColor { get; } = "Nici o culoare";
        public override string QuickAccessToolBarDropDownButtonTooltip { get; } = "Personalizează Bara de Acces Rapid";
        public override string QuickAccessToolBarMenuHeader { get; } = "Personalizează Bara de Acces Rapid";
        public override string QuickAccessToolBarMenuShowAbove { get; } = "Afișează peste Ribbon";
        public override string QuickAccessToolBarMenuShowBelow { get; } = "Afișează sub Ribbon";
        public override string QuickAccessToolBarMoreControlsButtonTooltip { get; } = "Mai multe controale";
        public override string RibbonContextMenuAddGallery { get; } = "Adaugă Galeria la Bara de Acess Rapid";
        public override string RibbonContextMenuAddGroup { get; } = "Adaugă Grupul la Bara de Acess Rapid";
        public override string RibbonContextMenuAddItem { get; } = "Adaugă la Bara de Acess Rapid";
        public override string RibbonContextMenuAddMenu { get; } = "Adaugă Meniul la Bara de Acess Rapid";
        public override string RibbonContextMenuCustomizeQuickAccessToolBar { get; } = "Personalizează Bara de Acces Rapid...";
        public override string RibbonContextMenuCustomizeRibbon { get; } = "Personalizează Ribbon-ul...";
        public override string RibbonContextMenuMinimizeRibbon { get; } = "Minimizează Ribbon-ul...";
        public override string RibbonContextMenuRemoveItem { get; } = "Eimină din Bara de Acess Rapid";
        public override string RibbonContextMenuShowAbove { get; } = "Afișează Bara de Acces Rapid peste Ribbon";
        public override string RibbonContextMenuShowBelow { get; } = "Afișează Bara de Acces Rapid sub Ribbon";
        public override string RibbonLayout { get; } = FallbackLocalization.RibbonLayout;
        public override string ScreenTipDisableReasonHeader { get; } = "Această comandă nu este disponibilă momentan.";
        public override string ScreenTipF1LabelHeader { get; } = FallbackLocalization.ScreenTipF1LabelHeader;
        public override string ShowRibbon { get; } = FallbackLocalization.ShowRibbon;
        public override string UseClassicRibbon { get; } = "_Utilizați panglica clasică";
        public override string UseSimplifiedRibbon { get; } = "_Utilizați panglica simplificată";
    }
}
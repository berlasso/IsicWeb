//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.5477
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FingerCapturer.Properties
{
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "9.0.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string SelectedFScannerId {
            get {
                return ((string)(this["SelectedFScannerId"]));
            }
            set {
                this["SelectedFScannerId"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool ScanSlaps {
            get {
                return ((bool)(this["ScanSlaps"]));
            }
            set {
                this["ScanSlaps"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool ScanRolled {
            get {
                return ((bool)(this["ScanRolled"]));
            }
            set {
                this["ScanRolled"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool ScanPlain {
            get {
                return ((bool)(this["ScanPlain"]));
            }
            set {
                this["ScanPlain"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool ShowOriginal {
            get {
                return ((bool)(this["ShowOriginal"]));
            }
            set {
                this["ShowOriginal"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public uint ExtractorMode {
            get {
                return ((uint)(this["ExtractorMode"]));
            }
            set {
                this["ExtractorMode"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public int MinMinutiaCount {
            get {
                return ((int)(this["MinMinutiaCount"]));
            }
            set {
                this["MinMinutiaCount"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public bool UseQuality {
            get {
                return ((bool)(this["UseQuality"]));
            }
            set {
                this["UseQuality"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public byte QualityThreshold {
            get {
                return ((byte)(this["QualityThreshold"]));
            }
            set {
                this["QualityThreshold"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Neurotec.Biometrics.NfeTemplateSize TemplateSize {
            get {
                return ((global::Neurotec.Biometrics.NfeTemplateSize)(this["TemplateSize"]));
            }
            set {
                this["TemplateSize"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Neurotec.Biometrics.NFRidgeCountsType RidgeCounts {
            get {
                return ((global::Neurotec.Biometrics.NFRidgeCountsType)(this["RidgeCounts"]));
            }
            set {
                this["RidgeCounts"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool UseCluster {
            get {
                return ((bool)(this["UseCluster"]));
            }
            set {
                this["UseCluster"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string ClusterTemplateField {
            get {
                return ((string)(this["ClusterTemplateField"]));
            }
            set {
                this["ClusterTemplateField"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string ClusterDbidField {
            get {
                return ((string)(this["ClusterDbidField"]));
            }
            set {
                this["ClusterDbidField"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string ClusterHashField {
            get {
                return ((string)(this["ClusterHashField"]));
            }
            set {
                this["ClusterHashField"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Key = \'Thumbnail\', IsThumbnail = \'True\', Editable = \'False\' ;Key = \'Name\' ;Key = " +
            "\'Middle Name\';Key = \'Last Name\' ;Key = \'National Id\'; Key = \'Nationality\'")]
        public string Information {
            get {
                return ((string)(this["Information"]));
            }
            set {
                this["Information"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Thumbnail")]
        public string InformationThumbnailField {
            get {
                return ((string)(this["InformationThumbnailField"]));
            }
            set {
                this["InformationThumbnailField"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("localhost")]
        public string ConnectionAddress {
            get {
                return ((string)(this["ConnectionAddress"]));
            }
            set {
                this["ConnectionAddress"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("24932")]
        public int ConnectionAdminPort {
            get {
                return ((int)(this["ConnectionAdminPort"]));
            }
            set {
                this["ConnectionAdminPort"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string ClientProperties {
            get {
                return ((string)(this["ClientProperties"]));
            }
            set {
                this["ClientProperties"] = value;
            }
        }
    }
}
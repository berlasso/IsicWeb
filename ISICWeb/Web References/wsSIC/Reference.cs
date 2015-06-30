﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by Microsoft.VSDesigner, Version 4.0.30319.42000.
// 
#pragma warning disable 1591

namespace ISICWeb.wsSIC {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.Xml.Serialization;
    using System.ComponentModel;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.76.2")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="ServicesBinding", Namespace="http://sic-site.mpba.gov.ar/soap/Services")]
    [System.Xml.Serialization.SoapIncludeAttribute(typeof(MyResultadoObject))]
    public partial class Services : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback PerfilUsuarioOperationCompleted;
        
        private System.Threading.SendOrPostCallback ProcessMyFiltroObjectOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public Services() {
            this.Url = global::ISICWeb.Properties.Settings.Default.ISICWeb_wsSIC_Services;
            if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        public new string Url {
            get {
                return base.Url;
            }
            set {
                if ((((this.IsLocalFileSystemWebService(base.Url) == true) 
                            && (this.useDefaultCredentialsSetExplicitly == false)) 
                            && (this.IsLocalFileSystemWebService(value) == false))) {
                    base.UseDefaultCredentials = false;
                }
                base.Url = value;
            }
        }
        
        public new bool UseDefaultCredentials {
            get {
                return base.UseDefaultCredentials;
            }
            set {
                base.UseDefaultCredentials = value;
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        /// <remarks/>
        public event PerfilUsuarioCompletedEventHandler PerfilUsuarioCompleted;
        
        /// <remarks/>
        public event ProcessMyFiltroObjectCompletedEventHandler ProcessMyFiltroObjectCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapRpcMethodAttribute("http://sic-site.mpba.gov.ar/cons1/webservice.php/PerfilUsuario", RequestNamespace="", ResponseNamespace="")]
        [return: System.Xml.Serialization.SoapElementAttribute("return")]
        public string PerfilUsuario(string login, string clave) {
            object[] results = this.Invoke("PerfilUsuario", new object[] {
                        login,
                        clave});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void PerfilUsuarioAsync(string login, string clave) {
            this.PerfilUsuarioAsync(login, clave, null);
        }
        
        /// <remarks/>
        public void PerfilUsuarioAsync(string login, string clave, object userState) {
            if ((this.PerfilUsuarioOperationCompleted == null)) {
                this.PerfilUsuarioOperationCompleted = new System.Threading.SendOrPostCallback(this.OnPerfilUsuarioOperationCompleted);
            }
            this.InvokeAsync("PerfilUsuario", new object[] {
                        login,
                        clave}, this.PerfilUsuarioOperationCompleted, userState);
        }
        
        private void OnPerfilUsuarioOperationCompleted(object arg) {
            if ((this.PerfilUsuarioCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.PerfilUsuarioCompleted(this, new PerfilUsuarioCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapRpcMethodAttribute("http://sic-site.mpba.gov.ar/cons1/webservice.php/ProcessMyFiltroObject", RequestNamespace="", ResponseNamespace="")]
        [return: System.Xml.Serialization.SoapElementAttribute("return")]
        public MyResultadoObject[] ProcessMyFiltroObject(MyFiltroObject soapObject) {
            object[] results = this.Invoke("ProcessMyFiltroObject", new object[] {
                        soapObject});
            return ((MyResultadoObject[])(results[0]));
        }
        
        /// <remarks/>
        public void ProcessMyFiltroObjectAsync(MyFiltroObject soapObject) {
            this.ProcessMyFiltroObjectAsync(soapObject, null);
        }
        
        /// <remarks/>
        public void ProcessMyFiltroObjectAsync(MyFiltroObject soapObject, object userState) {
            if ((this.ProcessMyFiltroObjectOperationCompleted == null)) {
                this.ProcessMyFiltroObjectOperationCompleted = new System.Threading.SendOrPostCallback(this.OnProcessMyFiltroObjectOperationCompleted);
            }
            this.InvokeAsync("ProcessMyFiltroObject", new object[] {
                        soapObject}, this.ProcessMyFiltroObjectOperationCompleted, userState);
        }
        
        private void OnProcessMyFiltroObjectOperationCompleted(object arg) {
            if ((this.ProcessMyFiltroObjectCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.ProcessMyFiltroObjectCompleted(this, new ProcessMyFiltroObjectCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
        
        private bool IsLocalFileSystemWebService(string url) {
            if (((url == null) 
                        || (url == string.Empty))) {
                return false;
            }
            System.Uri wsUri = new System.Uri(url);
            if (((wsUri.Port >= 1024) 
                        && (string.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) == 0))) {
                return true;
            }
            return false;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.76.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.SoapTypeAttribute(Namespace="http://sic-site.mpba.gov.ar/soap/Services")]
    public partial class MyFiltroObject {
        
        private string codUsuarioField;
        
        private string fisGralField;
        
        private string domicilioField;
        
        private string localidadField;
        
        private string nombreField;
        
        private string apellidoField;
        
        private string docNroField;
        
        private string tatuajeField;
        
        private string iPPField;
        
        private string sexoField;
        
        private string edadAproxField;
        
        private string cantResultadosField;
        
        private string estaturaField;
        
        private string robustezField;
        
        private string colorOjosField;
        
        private string colorPielField;
        
        private string colorCabelloField;
        
        private string tipoCabelloField;
        
        private string calvicieField;
        
        private string formaCaraField;
        
        private string dimensionCejaField;
        
        private string formaCejaField;
        
        private string formaMentonField;
        
        private string formaOrejaField;
        
        private string formaNarizField;
        
        private string formaBocaField;
        
        private string labioInferiorField;
        
        private string labioSuperiorField;
        
        /// <remarks/>
        public string codUsuario {
            get {
                return this.codUsuarioField;
            }
            set {
                this.codUsuarioField = value;
            }
        }
        
        /// <remarks/>
        public string fisGral {
            get {
                return this.fisGralField;
            }
            set {
                this.fisGralField = value;
            }
        }
        
        /// <remarks/>
        public string domicilio {
            get {
                return this.domicilioField;
            }
            set {
                this.domicilioField = value;
            }
        }
        
        /// <remarks/>
        public string localidad {
            get {
                return this.localidadField;
            }
            set {
                this.localidadField = value;
            }
        }
        
        /// <remarks/>
        public string nombre {
            get {
                return this.nombreField;
            }
            set {
                this.nombreField = value;
            }
        }
        
        /// <remarks/>
        public string apellido {
            get {
                return this.apellidoField;
            }
            set {
                this.apellidoField = value;
            }
        }
        
        /// <remarks/>
        public string docNro {
            get {
                return this.docNroField;
            }
            set {
                this.docNroField = value;
            }
        }
        
        /// <remarks/>
        public string tatuaje {
            get {
                return this.tatuajeField;
            }
            set {
                this.tatuajeField = value;
            }
        }
        
        /// <remarks/>
        public string IPP {
            get {
                return this.iPPField;
            }
            set {
                this.iPPField = value;
            }
        }
        
        /// <remarks/>
        public string sexo {
            get {
                return this.sexoField;
            }
            set {
                this.sexoField = value;
            }
        }
        
        /// <remarks/>
        public string edadAprox {
            get {
                return this.edadAproxField;
            }
            set {
                this.edadAproxField = value;
            }
        }
        
        /// <remarks/>
        public string cantResultados {
            get {
                return this.cantResultadosField;
            }
            set {
                this.cantResultadosField = value;
            }
        }
        
        /// <remarks/>
        public string estatura {
            get {
                return this.estaturaField;
            }
            set {
                this.estaturaField = value;
            }
        }
        
        /// <remarks/>
        public string robustez {
            get {
                return this.robustezField;
            }
            set {
                this.robustezField = value;
            }
        }
        
        /// <remarks/>
        public string colorOjos {
            get {
                return this.colorOjosField;
            }
            set {
                this.colorOjosField = value;
            }
        }
        
        /// <remarks/>
        public string colorPiel {
            get {
                return this.colorPielField;
            }
            set {
                this.colorPielField = value;
            }
        }
        
        /// <remarks/>
        public string colorCabello {
            get {
                return this.colorCabelloField;
            }
            set {
                this.colorCabelloField = value;
            }
        }
        
        /// <remarks/>
        public string tipoCabello {
            get {
                return this.tipoCabelloField;
            }
            set {
                this.tipoCabelloField = value;
            }
        }
        
        /// <remarks/>
        public string calvicie {
            get {
                return this.calvicieField;
            }
            set {
                this.calvicieField = value;
            }
        }
        
        /// <remarks/>
        public string formaCara {
            get {
                return this.formaCaraField;
            }
            set {
                this.formaCaraField = value;
            }
        }
        
        /// <remarks/>
        public string dimensionCeja {
            get {
                return this.dimensionCejaField;
            }
            set {
                this.dimensionCejaField = value;
            }
        }
        
        /// <remarks/>
        public string formaCeja {
            get {
                return this.formaCejaField;
            }
            set {
                this.formaCejaField = value;
            }
        }
        
        /// <remarks/>
        public string formaMenton {
            get {
                return this.formaMentonField;
            }
            set {
                this.formaMentonField = value;
            }
        }
        
        /// <remarks/>
        public string formaOreja {
            get {
                return this.formaOrejaField;
            }
            set {
                this.formaOrejaField = value;
            }
        }
        
        /// <remarks/>
        public string formaNariz {
            get {
                return this.formaNarizField;
            }
            set {
                this.formaNarizField = value;
            }
        }
        
        /// <remarks/>
        public string formaBoca {
            get {
                return this.formaBocaField;
            }
            set {
                this.formaBocaField = value;
            }
        }
        
        /// <remarks/>
        public string labioInferior {
            get {
                return this.labioInferiorField;
            }
            set {
                this.labioInferiorField = value;
            }
        }
        
        /// <remarks/>
        public string labioSuperior {
            get {
                return this.labioSuperiorField;
            }
            set {
                this.labioSuperiorField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.76.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.SoapTypeAttribute(Namespace="http://sic-site.mpba.gov.ar/soap/Services")]
    public partial class MyResultadoObject {
        
        private string paisNacField;
        
        private string codbarraField;
        
        private string nroCarpetaField;
        
        private string tatuajeField;
        
        private string prontuarioSicField;
        
        private string apellidoField;
        
        private string nombresField;
        
        private string tipoDOCField;
        
        private string docNroField;
        
        private string feNacField;
        
        private string lugarNacField;
        
        private string pciaNacField;
        
        private string caratulaField;
        
        private string fechaField;
        
        private string ippField;
        
        private string linkSicField;
        
        private string sexoField;
        
        /// <remarks/>
        public string PaisNac {
            get {
                return this.paisNacField;
            }
            set {
                this.paisNacField = value;
            }
        }
        
        /// <remarks/>
        public string codbarra {
            get {
                return this.codbarraField;
            }
            set {
                this.codbarraField = value;
            }
        }
        
        /// <remarks/>
        public string NroCarpeta {
            get {
                return this.nroCarpetaField;
            }
            set {
                this.nroCarpetaField = value;
            }
        }
        
        /// <remarks/>
        public string tatuaje {
            get {
                return this.tatuajeField;
            }
            set {
                this.tatuajeField = value;
            }
        }
        
        /// <remarks/>
        public string ProntuarioSic {
            get {
                return this.prontuarioSicField;
            }
            set {
                this.prontuarioSicField = value;
            }
        }
        
        /// <remarks/>
        public string Apellido {
            get {
                return this.apellidoField;
            }
            set {
                this.apellidoField = value;
            }
        }
        
        /// <remarks/>
        public string Nombres {
            get {
                return this.nombresField;
            }
            set {
                this.nombresField = value;
            }
        }
        
        /// <remarks/>
        public string TipoDOC {
            get {
                return this.tipoDOCField;
            }
            set {
                this.tipoDOCField = value;
            }
        }
        
        /// <remarks/>
        public string DocNro {
            get {
                return this.docNroField;
            }
            set {
                this.docNroField = value;
            }
        }
        
        /// <remarks/>
        public string FeNac {
            get {
                return this.feNacField;
            }
            set {
                this.feNacField = value;
            }
        }
        
        /// <remarks/>
        public string LugarNac {
            get {
                return this.lugarNacField;
            }
            set {
                this.lugarNacField = value;
            }
        }
        
        /// <remarks/>
        public string PciaNac {
            get {
                return this.pciaNacField;
            }
            set {
                this.pciaNacField = value;
            }
        }
        
        /// <remarks/>
        public string caratula {
            get {
                return this.caratulaField;
            }
            set {
                this.caratulaField = value;
            }
        }
        
        /// <remarks/>
        public string Fecha {
            get {
                return this.fechaField;
            }
            set {
                this.fechaField = value;
            }
        }
        
        /// <remarks/>
        public string ipp {
            get {
                return this.ippField;
            }
            set {
                this.ippField = value;
            }
        }
        
        /// <remarks/>
        public string linkSic {
            get {
                return this.linkSicField;
            }
            set {
                this.linkSicField = value;
            }
        }
        
        /// <remarks/>
        public string Sexo {
            get {
                return this.sexoField;
            }
            set {
                this.sexoField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.76.2")]
    public delegate void PerfilUsuarioCompletedEventHandler(object sender, PerfilUsuarioCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.76.2")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class PerfilUsuarioCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal PerfilUsuarioCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.76.2")]
    public delegate void ProcessMyFiltroObjectCompletedEventHandler(object sender, ProcessMyFiltroObjectCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.76.2")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class ProcessMyFiltroObjectCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal ProcessMyFiltroObjectCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public MyResultadoObject[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((MyResultadoObject[])(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591
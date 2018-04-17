﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SchoolSystem.Abstractions.Exceptions {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "15.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class ExceptionMessages {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal ExceptionMessages() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("SchoolSystem.Abstractions.Exceptions.ExceptionMessages", typeof(ExceptionMessages).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Can&apos;t resolve command handler.
        /// </summary>
        internal static string CommandHandlerNotFoundException {
            get {
                return ResourceManager.GetString("CommandHandlerNotFoundException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Validator is corrupted.
        /// </summary>
        internal static string CorruptedValidatorException {
            get {
                return ResourceManager.GetString("CorruptedValidatorException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Entity of selected type not found.
        /// </summary>
        internal static string EntityNotFoundException {
            get {
                return ResourceManager.GetString("EntityNotFoundException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Command validator is missed or not registred.
        /// </summary>
        internal static string MissingCommandValidatorException {
            get {
                return ResourceManager.GetString("MissingCommandValidatorException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Query handler is missed or not registred.
        /// </summary>
        internal static string MissingQueryValidatorException {
            get {
                return ResourceManager.GetString("MissingQueryValidatorException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Can&apos;t resolve query handler.
        /// </summary>
        internal static string QueryHandlerNotFoundException {
            get {
                return ResourceManager.GetString("QueryHandlerNotFoundException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Object is in invalid state.
        /// </summary>
        internal static string ValidationException {
            get {
                return ResourceManager.GetString("ValidationException", resourceCulture);
            }
        }
    }
}
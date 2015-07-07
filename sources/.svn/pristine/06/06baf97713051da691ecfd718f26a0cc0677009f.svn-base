using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

/// <summary>
/// Metadata classes are not always automatically registered, for example in a UnitTest classlibrary.
/// This class can be used to register all metadata classes find in this assembly.
/// 
/// Registration will only be done once.
/// </summary>
public static class MetadataTypesRegister
{
    private static bool _installed = false;
    private static readonly object InstalledLock = new object();


    /// <summary>
    /// Register all metadata classes found in this assembly.
    /// Registration will only be done once.        
    /// </summary>
    public static void InstallForAssembly()
    {
        if (_installed)
        {
            return;
        }

        lock (InstalledLock)
        {
            if (_installed)
            {
                return;
            }

            foreach (Type type in Assembly.GetExecutingAssembly().GetTypes())
            {
                foreach (MetadataTypeAttribute attrib in type.GetCustomAttributes(typeof(MetadataTypeAttribute), true))
                {
                    TypeDescriptor.AddProviderTransparent(new AssociatedMetadataTypeTypeDescriptionProvider(type, attrib.MetadataClassType), type);
                }
            }

            _installed = true;
        }
    }
}
---
kind: property
id: P:Autodesk.Revit.DB.ExternalResourceLoadContent.Version
source: html/6a233453-4300-627c-450d-c038fe378195.htm
---
# Autodesk.Revit.DB.ExternalResourceLoadContent.Version Property

The version of the external data that the server is providing in this object.

## Syntax (C#)
```csharp
public string Version { get; set; }
```

## Remarks
When its LoadResource() method is invoked, an IExternalResourceServer can
 indicate the version of the data that it is providing to Revit by setting
 this property. Doing so will improve performance, because Revit will use
 the version information to avoid unnecessary reloads. See GetResourceVersionStatus(ExternalResourceReference) .

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - When setting this property: A non-optional argument was null


---
kind: property
id: P:Autodesk.Revit.ApplicationServices.Application.SharedParametersFilename
source: html/d6b43cc8-9521-9ab3-569e-5e0c7a0205a8.htm
---
# Autodesk.Revit.ApplicationServices.Application.SharedParametersFilename Property

Contains the fully qualified path to a shared parameters file.

## Syntax (C#)
```csharp
public string SharedParametersFilename { get; set; }
```

## Remarks
This path can be read and set via this property. By default Autodesk Revit does not have
a shared parameters file so this property must be set before access is made to the shared parameters
file object otherwise an exception will be thrown.


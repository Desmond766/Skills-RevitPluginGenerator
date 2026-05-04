---
kind: property
id: P:Autodesk.Revit.ApplicationServices.ControlledApplication.SharedParametersFilename
source: html/513e3512-4c82-4b20-b3e9-c33c3ee4cd61.htm
---
# Autodesk.Revit.ApplicationServices.ControlledApplication.SharedParametersFilename Property

Contains the fully qualified path to a shared parameters file.

## Syntax (C#)
```csharp
public string SharedParametersFilename { get; set; }
```

## Remarks
This path can be read and set via this property. By default Autodesk Revit does not have
a shared parameters file so this property must be set before access is made to the shared parameters
file object otherwise an exception will be thrown.


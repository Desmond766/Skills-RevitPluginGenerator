---
kind: property
id: P:Autodesk.Revit.DB.ColorFillScheme.ParameterDefinition
source: html/554f7720-d040-ebcf-5986-9910b8038b87.htm
---
# Autodesk.Revit.DB.ColorFillScheme.ParameterDefinition Property

Represents the parameter of the elements that this scheme could be used to color.

## Syntax (C#)
```csharp
public ElementId ParameterDefinition { get; set; }
```

## Remarks
When this property changed, all existing scheme entries will be removed from the scheme,
 and the value of IsByRange property will be set to false if the parameter
 storage type is not numeric.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - When setting this property: The paramId cannot be applied to the scheme.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - When setting this property: A non-optional argument was null


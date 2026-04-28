---
kind: property
id: P:Autodesk.Revit.DB.Architecture.BalusterPattern.ExcessLengthFillBalusterId
source: html/f65fecb5-e3c1-6a68-dd67-c4e951efdc74.htm
---
# Autodesk.Revit.DB.Architecture.BalusterPattern.ExcessLengthFillBalusterId Property

The id of a Baluster family used to fill excess length, which is the extra space
 along the railing segment that cannot be filled with a pattern.
 If set to InvalidElementId, it will be the default - the id of the BaseRailingAttr containing the Baluster pattern.

## Syntax (C#)
```csharp
public ElementId ExcessLengthFillBalusterId { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - When setting this property: Invalid ElementId for leftoverFill of BalusterPattern
- **Autodesk.Revit.Exceptions.ArgumentNullException** - When setting this property: A non-optional argument was null


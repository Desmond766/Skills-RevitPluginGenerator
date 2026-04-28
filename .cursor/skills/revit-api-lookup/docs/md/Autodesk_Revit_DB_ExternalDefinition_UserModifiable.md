---
kind: property
id: P:Autodesk.Revit.DB.ExternalDefinition.UserModifiable
source: html/4568f90c-7d4b-c9f2-da59-1540ca14a22f.htm
---
# Autodesk.Revit.DB.ExternalDefinition.UserModifiable Property

Indicates whether the parameter can be modified by the user interface.

## Syntax (C#)
```csharp
public bool UserModifiable { get; }
```

## Remarks
If true, the user can edit the value of this parameter. If false, the user cannot edit this value
 (it will appear grayed out). However, any API application can modify the value of this parameter.


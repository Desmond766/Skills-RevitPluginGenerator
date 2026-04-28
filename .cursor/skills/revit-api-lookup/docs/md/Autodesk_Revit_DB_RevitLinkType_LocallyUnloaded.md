---
kind: property
id: P:Autodesk.Revit.DB.RevitLinkType.LocallyUnloaded
source: html/ae370efc-5079-dbd8-5fb5-713086aae86e.htm
---
# Autodesk.Revit.DB.RevitLinkType.LocallyUnloaded Property

Checks whether a Revit link in a local model is unloaded
 only for the current user.

## Syntax (C#)
```csharp
public bool LocallyUnloaded { get; }
```

## Remarks
Revit links can be unloaded for both the current user
 and for all users.
 If a Revit link is in a non-workshared file or in central model,
 this property is false.


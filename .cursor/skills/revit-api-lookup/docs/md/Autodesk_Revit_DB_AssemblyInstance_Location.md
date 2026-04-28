---
kind: property
id: P:Autodesk.Revit.DB.AssemblyInstance.Location
source: html/f1ffc6ac-24ce-4d10-9c9a-24a99ffaf94d.htm
---
# Autodesk.Revit.DB.AssemblyInstance.Location Property

This property is used to find the physical location of the assembly instance within project.

## Syntax (C#)
```csharp
public override Location Location { get; }
```

## Remarks
The Location property returns an object that can be used to find the location of an object
within the project. Assembly instances return a point location object positioned at the center of the assembly instance.


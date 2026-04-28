---
kind: property
id: P:Autodesk.Revit.DB.FamilyInstance.Location
zh: 族实例
source: html/847ff799-9b1b-0982-f55a-7273c55b196d.htm
---
# Autodesk.Revit.DB.FamilyInstance.Location Property

**中文**: 族实例

This property is used to find the physical location of an instance within project.

## Syntax (C#)
```csharp
public override Location Location { get; }
```

## Remarks
The Location property returns an object that can be used to find the location of an instance
within the project. An instance may have a point location, such as a footing or may have a line location.
A beam is an example of an instance that has a line location.


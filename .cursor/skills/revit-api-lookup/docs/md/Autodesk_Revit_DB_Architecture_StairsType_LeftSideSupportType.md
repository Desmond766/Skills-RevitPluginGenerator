---
kind: property
id: P:Autodesk.Revit.DB.Architecture.StairsType.LeftSideSupportType
source: html/937a6510-30b8-2a23-3c26-687fa8daa8f3.htm
---
# Autodesk.Revit.DB.Architecture.StairsType.LeftSideSupportType Property

The type of left support used in the stair.

## Syntax (C#)
```csharp
public ElementId LeftSideSupportType { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - When setting this property: leftSideStringerTypeId is not a valid support type.
 -or-
 When setting this property: The specified leftSideStringerTypeId doesn't match the desired style of the left side support.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - When setting this property: A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - When setting this property: The left support style is none, so this related data cannot be set.


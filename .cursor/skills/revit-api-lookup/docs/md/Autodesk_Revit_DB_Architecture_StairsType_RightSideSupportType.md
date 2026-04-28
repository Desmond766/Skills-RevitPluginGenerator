---
kind: property
id: P:Autodesk.Revit.DB.Architecture.StairsType.RightSideSupportType
source: html/71dffec6-4011-e761-4abf-be9988206ac3.htm
---
# Autodesk.Revit.DB.Architecture.StairsType.RightSideSupportType Property

The type of right support used in the stair.

## Syntax (C#)
```csharp
public ElementId RightSideSupportType { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - When setting this property: rightSideStringerTypeId is not a valid support type.
 -or-
 When setting this property: The specified rightSideStringerTypeId doesn't match the desired style of the right side support.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - When setting this property: A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - When setting this property: The right support style is none, so this related data cannot be set.


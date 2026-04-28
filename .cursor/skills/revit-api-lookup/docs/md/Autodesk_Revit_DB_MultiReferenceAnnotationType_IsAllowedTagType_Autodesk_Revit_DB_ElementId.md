---
kind: method
id: M:Autodesk.Revit.DB.MultiReferenceAnnotationType.IsAllowedTagType(Autodesk.Revit.DB.ElementId)
source: html/4f7f0cf5-ed38-ec2c-cfc9-7568b29a4601.htm
---
# Autodesk.Revit.DB.MultiReferenceAnnotationType.IsAllowedTagType Method

Checks if the tag type can be assigned to this multi-reference annotation type.

## Syntax (C#)
```csharp
public bool IsAllowedTagType(
	ElementId tagTypeId
)
```

## Parameters
- **tagTypeId** (`Autodesk.Revit.DB.ElementId`) - The tag type to test.

## Returns
True if the tag type exclusively tags elements from the multi-reference annotation's reference category.

## Remarks
Only tag types which exclusively tag elements from the multi-reference annotation's reference category can be used.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null


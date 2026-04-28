---
kind: method
id: M:Autodesk.Revit.DB.ViewSection.IsViewFamilyTypeValidForCallout(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.ElementId)
zh: 剖面视图、剖面
source: html/4bbd3a68-ca33-38e9-5a37-3be857b54cff.htm
---
# Autodesk.Revit.DB.ViewSection.IsViewFamilyTypeValidForCallout Method

**中文**: 剖面视图、剖面

This validator checks that the ViewFamilyType is appropriate for callout views in the
 input parent view.

## Syntax (C#)
```csharp
public static bool IsViewFamilyTypeValidForCallout(
	Document document,
	ElementId viewFamilyTypeId,
	ElementId parentViewId
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document which contains the ViewFamilyType and parent view.
- **viewFamilyTypeId** (`Autodesk.Revit.DB.ElementId`) - The id of the ViewFamilyType which will be used by the new callout ViewSection.
 Detail ViewFamilyTypes can be used in all parent views except for CeilingPlan and Drafting views.
 FloorPlan, CeilingPlan, StructuralPlan, Section, Elevation, and Detail ViewFamilyTypes may be
 be used in parent views that also use a type with the same ViewFamily enum value.
 For example, in StructuralPlan views both StructuralPlan and Detail ViewFamilyTypes are allowed.
- **parentViewId** (`Autodesk.Revit.DB.ElementId`) - The view in which the new callout will appear.
 Callouts can be created in FloorPlan, CeilingPlan, StructuralPlan, Section, Elevation,
 and Detail views.

## Returns
True if the ViewFamilyType can be used for callout views in the parent view, false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null


---
kind: method
id: M:Autodesk.Revit.DB.ViewPlan.Create(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.ElementId)
zh: 创建、新建、生成、建立、新增
source: html/aa8f2c2e-dfd9-fda5-8d61-31580cbce408.htm
---
# Autodesk.Revit.DB.ViewPlan.Create Method

**中文**: 创建、新建、生成、建立、新增

Creates a new ViewPlan.

## Syntax (C#)
```csharp
public static ViewPlan Create(
	Document document,
	ElementId viewFamilyTypeId,
	ElementId levelId
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document to which the ViewPlan will be added.
- **viewFamilyTypeId** (`Autodesk.Revit.DB.ElementId`) - The id of the ViewFamilyType which will be used by the new ViewPlan. The type needs to be a FloorPlan, CeilingPlan, AreaPlan, or StructuralPlan ViewType.
- **levelId** (`Autodesk.Revit.DB.ElementId`) - The id of the Level to associate with the new plan view.

## Returns
The new ViewPlan.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - This view family type is not a plan view type.
 -or-
 The ElementId levelId does not correspond to a Level.
 -or-
 StructuralPlans can only be created when the structural discipline is enabled whereas FloorPlans and CeilingPlans can
 only be created when architecture or MEP disciplines are enabled.
 -or-
 Plan view creation is not allowed in this family.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ModificationForbiddenException** - The document is in failure mode: an operation has failed,
 and Revit requires the user to either cancel the operation
 or fix the problem (usually by deleting certain elements).
 -or-
 The document is being loaded, or is in the midst of another
 sensitive process.
- **Autodesk.Revit.Exceptions.ModificationOutsideTransactionException** - The document has no open transaction.


---
kind: method
id: M:Autodesk.Revit.DB.ReferenceableViewUtils.ChangeReferencedView(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.ElementId)
source: html/e62f67ee-ee95-8ffb-7896-22cce7280066.htm
---
# Autodesk.Revit.DB.ReferenceableViewUtils.ChangeReferencedView Method

Changes a particular reference view (such as a reference section or reference callout) to refer to a different View.

## Syntax (C#)
```csharp
public static void ChangeReferencedView(
	Document document,
	ElementId referenceId,
	ElementId desiredViewId
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document containing the elements.
- **referenceId** (`Autodesk.Revit.DB.ElementId`) - The reference view that will be changed to refer to a different View.
- **desiredViewId** (`Autodesk.Revit.DB.ElementId`) - The id of the View that the reference section or callout will refer to.

## Remarks
Reference views may not refer to a View in which their own graphics (such as the section or callout
 graphics) will appear. If the reference view's ViewFamilyType is not appropriate
 for the new View, Revit will automatically change the ViewFamilyType during regeneration. This
 typically occurs when the referenced view is changed from a model View to a drafting View or
 vice-versa.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - referenceId is not a valid reference view.
 -or-
 desiredViewId is not a view that can be referenced by referenceId.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null


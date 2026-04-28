---
kind: method
id: M:Autodesk.Revit.DB.WorksharingUtils.GetCheckoutStatus(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId,System.String@)
source: html/8359bb9a-01d2-d595-c72b-718c70841511.htm
---
# Autodesk.Revit.DB.WorksharingUtils.GetCheckoutStatus Method

Gets the ownership status and outputs the owner of an element.

## Syntax (C#)
```csharp
public static CheckoutStatus GetCheckoutStatus(
	Document document,
	ElementId elementId,
	out string owner
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document containing the element.
- **elementId** (`Autodesk.Revit.DB.ElementId`) - The id of the element.
- **owner** (`System.String %`) - The owner of the element, or an empty string if no one owns it.

## Returns
An indication of whether the element is unowned, owned by the current user, or owned by another user.

## Remarks
This method returns a locally cached value which may not be up to date with the current state
 of the element in the central. Because of this, the return value is suitable for reporting to an
 interactive user (e.g. via a mechanism similar to Worksharing display mode), but cannot be considered
 a reliable indication of whether the element can be immediately edited by the application. Also, the return value
 may not be dependable in the middle of a local transaction. See the remarks
 on WorksharingUtils for more details. For performance reasons, the model is not validated to be workshared,
 and the element id is also not validated; the element will not be expanded.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null


---
kind: method
id: M:Autodesk.Revit.UI.UIDocument.CanPlaceElementType(Autodesk.Revit.DB.ElementType)
source: html/d9264f5e-333d-73df-0f9a-02b4c0722206.htm
---
# Autodesk.Revit.UI.UIDocument.CanPlaceElementType Method

Verifies that the user can be prompted to place the input element type interactively.

## Syntax (C#)
```csharp
public bool CanPlaceElementType(
	ElementType elementType
)
```

## Parameters
- **elementType** (`Autodesk.Revit.DB.ElementType`) - The ElementType.

## Returns
True if the user can be prompted to place the input element type interactively, false otherwise.

## Remarks
If an element type can be placed interactively, it may be used as input to PostRequestForElementTypePlacement(ElementType) 
 to have the user place an instance of the element. However, this function does not evaluate whether that element instance may
 actually be placed in the current active view.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null


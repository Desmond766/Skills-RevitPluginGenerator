---
kind: method
id: M:Autodesk.Revit.DB.Element.CanBeHidden(Autodesk.Revit.DB.View)
zh: 构件、图元、元素
source: html/887010c4-de58-96b6-0931-4c226e6b142b.htm
---
# Autodesk.Revit.DB.Element.CanBeHidden Method

**中文**: 构件、图元、元素

Indicates if the element can be hidden in the view.

## Syntax (C#)
```csharp
public bool CanBeHidden(
	View pView
)
```

## Parameters
- **pView** (`Autodesk.Revit.DB.View`)

## Returns
If the element is not permitted to be hidden, false is returned.

## Remarks
See discussion for some types of elements which may not be hidden.
 Note: elements in families can only be hidden temporarily.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown when argument is Nothing nullptr a null reference ( Nothing in Visual Basic) .


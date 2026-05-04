---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarConstraintsManager.ClearHandleConstraintPairHighlighting(Autodesk.Revit.DB.Document)
source: html/5a96c36b-097c-0f79-1919-595c1aa7a351.htm
---
# Autodesk.Revit.DB.Structure.RebarConstraintsManager.ClearHandleConstraintPairHighlighting Method

Clears all highlighting in all views.

## Syntax (C#)
```csharp
public void ClearHandleConstraintPairHighlighting(
	Document aDoc
)
```

## Parameters
- **aDoc** (`Autodesk.Revit.DB.Document`)

## Remarks
If highlightHandleConstraintPairInAllViews has been called, then this method can
 be used to remove all highlighting.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null


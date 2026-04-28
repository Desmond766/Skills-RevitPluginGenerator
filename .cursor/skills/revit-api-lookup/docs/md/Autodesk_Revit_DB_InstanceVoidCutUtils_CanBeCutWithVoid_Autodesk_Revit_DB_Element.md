---
kind: method
id: M:Autodesk.Revit.DB.InstanceVoidCutUtils.CanBeCutWithVoid(Autodesk.Revit.DB.Element)
source: html/02b7a1e0-dad7-32c5-e0f6-960d2e3c9776.htm
---
# Autodesk.Revit.DB.InstanceVoidCutUtils.CanBeCutWithVoid Method

Indicates if the element can be cut by an instance with unattached voids.

## Syntax (C#)
```csharp
public static bool CanBeCutWithVoid(
	Element element
)
```

## Parameters
- **element** (`Autodesk.Revit.DB.Element`) - The element to be cut

## Returns
Returns true if the element can be cut by an instance with unattached voids.

## Remarks
Elements in a project can be cut if they are host elements or family instances
 with a category Generic Model or one of the structural categories.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null


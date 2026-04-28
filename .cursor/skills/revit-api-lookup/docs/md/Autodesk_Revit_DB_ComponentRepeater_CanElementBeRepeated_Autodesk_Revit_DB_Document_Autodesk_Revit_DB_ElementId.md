---
kind: method
id: M:Autodesk.Revit.DB.ComponentRepeater.CanElementBeRepeated(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId)
source: html/85030abd-7476-91fc-a67b-50dd8bcf9697.htm
---
# Autodesk.Revit.DB.ComponentRepeater.CanElementBeRepeated Method

Determines whether an element can be repeated using the RepeatElements method.

## Syntax (C#)
```csharp
public static bool CanElementBeRepeated(
	Document ADoc,
	ElementId elementId
)
```

## Parameters
- **ADoc** (`Autodesk.Revit.DB.Document`) - The document containing the element.
- **elementId** (`Autodesk.Revit.DB.ElementId`) - The element to be tested.

## Returns
True if the element can be repeated.

## Remarks
The element must be an adaptive family instance and have no shape handles.
 At least one placement point must be hosted on a 1D or 2D repeating reference.
 All other placement points can be hosted on a 0D, 1D or 2D repeating reference,
 or must be unhosted.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null


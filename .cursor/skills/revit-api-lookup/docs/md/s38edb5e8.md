---
kind: method
id: M:Autodesk.Revit.UI.SelectionUIOptions.ElementSelectsAsPinned(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.Element)
source: html/97efea2e-4101-c63d-ba3b-a3b9a67e3b01.htm
---
# Autodesk.Revit.UI.SelectionUIOptions.ElementSelectsAsPinned Method

Checks whether the specified element will be treated as pinned for the purposes of selection.

## Syntax (C#)
```csharp
public static bool ElementSelectsAsPinned(
	Document document,
	Element element
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document containing the element.
- **element** (`Autodesk.Revit.DB.Element`) - The element to check.

## Returns
True if the specified element should be treated as pinned for selection purposes, false otherwise.

## Remarks
To improve usability, the option to disable pinned selection has some additional intelligence
 beyond simply checking the pinned status. For example, if a model group is pinned, the corresponding
 attached detail group will also be treated as pinned for the purposes of selection. If this method
 returns true, the specified element will not be selectable when selection of pinned elements is
 disabled.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null


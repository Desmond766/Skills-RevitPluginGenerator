---
kind: method
id: M:Autodesk.Revit.DB.Electrical.CableTray.IsValidCableTrayType(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId)
zh: 桥架、线槽
source: html/d379ecb0-0961-e029-7400-71fb1dd614d9.htm
---
# Autodesk.Revit.DB.Electrical.CableTray.IsValidCableTrayType Method

**中文**: 桥架、线槽

Identifies if a cable tray type is valid.

## Syntax (C#)
```csharp
public static bool IsValidCableTrayType(
	Document document,
	ElementId cabletrayType
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document.
- **cabletrayType** (`Autodesk.Revit.DB.ElementId`) - The cable tray type.

## Returns
True if the cable tray type is valid, false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null


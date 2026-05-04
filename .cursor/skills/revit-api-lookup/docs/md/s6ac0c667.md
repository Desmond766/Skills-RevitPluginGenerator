---
kind: method
id: M:Autodesk.Revit.DB.Architecture.Railing.IsValidHostForNewRailing(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId)
zh: 栏杆
source: html/cc1aaa43-f61a-e65d-eac9-43370200295a.htm
---
# Autodesk.Revit.DB.Architecture.Railing.IsValidHostForNewRailing Method

**中文**: 栏杆

Checks whether new railing can be created and placed on the specified host.

## Syntax (C#)
```csharp
public static bool IsValidHostForNewRailing(
	Document document,
	ElementId elementId
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document.
- **elementId** (`Autodesk.Revit.DB.ElementId`) - The element to check.

## Returns
True if new railing can be created and placed on the host, False otherwise.

## Remarks
This function will return true for stairs or ramps which can host new railings.
 Stairs or ramps can host new railings only when they have no associated railing and they are not in editing mode.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null


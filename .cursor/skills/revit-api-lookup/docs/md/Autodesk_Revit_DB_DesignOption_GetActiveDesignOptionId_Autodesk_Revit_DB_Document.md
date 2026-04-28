---
kind: method
id: M:Autodesk.Revit.DB.DesignOption.GetActiveDesignOptionId(Autodesk.Revit.DB.Document)
source: html/d0b47e58-a5fc-9424-a94c-2428b4ec4d16.htm
---
# Autodesk.Revit.DB.DesignOption.GetActiveDesignOptionId Method

Gets the active design option id for the current design option set.

## Syntax (C#)
```csharp
public static ElementId GetActiveDesignOptionId(
	Document document
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document.

## Returns
The active design option id. It can be invalid id if there is no active design option in the model.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null


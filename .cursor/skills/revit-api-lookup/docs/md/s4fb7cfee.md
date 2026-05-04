---
kind: property
id: P:Autodesk.Revit.DB.IViewSheetSet.OrderedViewList
source: html/fd9a9560-5984-91ee-f888-6550524215b9.htm
---
# Autodesk.Revit.DB.IViewSheetSet.OrderedViewList Property

Ordered views.

## Syntax (C#)
```csharp
IReadOnlyList<View> OrderedViewList { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown when the input ordered view list is Nothing nullptr a null reference ( Nothing in Visual Basic) .
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when the set operation failed due to invalid view which cannot be printed.


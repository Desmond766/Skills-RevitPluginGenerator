---
kind: property
id: P:Autodesk.Revit.DB.ViewSheetSet.OrderedViewList
source: html/b1f18496-a13a-657f-c47c-8973d4d8a7a3.htm
---
# Autodesk.Revit.DB.ViewSheetSet.OrderedViewList Property

Ordered views.

## Syntax (C#)
```csharp
public virtual IReadOnlyList<View> OrderedViewList { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown when the input ordered view list is Nothing nullptr a null reference ( Nothing in Visual Basic) .
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when the set operation failed due to invalid view which cannot be printed.


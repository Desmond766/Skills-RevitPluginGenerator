---
kind: property
id: P:Autodesk.Revit.DB.InSessionViewSheetSet.OrderedViewList
source: html/0bfb7fac-a347-6aeb-c853-1c438cb407cc.htm
---
# Autodesk.Revit.DB.InSessionViewSheetSet.OrderedViewList Property

Ordered views.

## Syntax (C#)
```csharp
public virtual IReadOnlyList<View> OrderedViewList { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown when the input ordered view list is Nothing nullptr a null reference ( Nothing in Visual Basic) .
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when the set operation failed due to invalid view which cannot be printed.


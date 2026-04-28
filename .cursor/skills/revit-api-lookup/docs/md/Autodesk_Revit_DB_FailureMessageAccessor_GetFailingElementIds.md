---
kind: method
id: M:Autodesk.Revit.DB.FailureMessageAccessor.GetFailingElementIds
source: html/3f01f592-4d76-4347-23d9-31becc3c54c0.htm
---
# Autodesk.Revit.DB.FailureMessageAccessor.GetFailingElementIds Method

Retrieves Ids of Elements that have caused the failure.

## Syntax (C#)
```csharp
public ICollection<ElementId> GetFailingElementIds()
```

## Returns
Ids of Elements that have caused the failure.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This FailureMessageAccessor has not been properly initialized.


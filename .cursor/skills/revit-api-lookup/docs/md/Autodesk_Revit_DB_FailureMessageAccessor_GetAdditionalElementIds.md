---
kind: method
id: M:Autodesk.Revit.DB.FailureMessageAccessor.GetAdditionalElementIds
source: html/20ad291f-15af-2e22-7091-e6115c6dd84b.htm
---
# Autodesk.Revit.DB.FailureMessageAccessor.GetAdditionalElementIds Method

Retrieves Ids of Elements that have not caused the failure but are related to it
 Checks if the failure has resolution of a given resolution type.

## Syntax (C#)
```csharp
public ICollection<ElementId> GetAdditionalElementIds()
```

## Returns
Ids of Elements related to the failure

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This FailureMessageAccessor has not been properly initialized.


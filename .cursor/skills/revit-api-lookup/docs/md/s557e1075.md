---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarConstraintsManager.GetAllHandles
source: html/1a8dbc43-88f6-8087-1607-7b01d61f4560.htm
---
# Autodesk.Revit.DB.Structure.RebarConstraintsManager.GetAllHandles Method

Gets all RebarConstrainedHandles of this bar.

## Syntax (C#)
```csharp
public IList<RebarConstrainedHandle> GetAllHandles()
```

## Returns
All RebarConstrainedHandle objects will be returned, regardless of whether there are constraints associated to them.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The RebarConstraintsManager does not manage a valid Rebar element.


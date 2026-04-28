---
kind: method
id: M:Autodesk.Revit.DB.ConnectionValidationWarning.GetParts
source: html/5cd40e6c-3912-6189-87bf-9eb7d9e131dd.htm
---
# Autodesk.Revit.DB.ConnectionValidationWarning.GetParts Method

Get ElementIds of affected parts.

## Syntax (C#)
```csharp
public ISet<ElementId> GetParts()
```

## Exceptions
- **Autodesk.Revit.Exceptions.DisabledDisciplineException** - None of the following disciplines is enabled: Mechanical Electrical Piping.


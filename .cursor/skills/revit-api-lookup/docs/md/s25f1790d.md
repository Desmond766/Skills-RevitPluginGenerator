---
kind: method
id: M:Autodesk.Revit.DB.ConnectorElement.AssignAsPrimary
source: html/c6c21445-5e95-e15b-743d-f8fdfb369e79.htm
---
# Autodesk.Revit.DB.ConnectorElement.AssignAsPrimary Method

Assign a connector as a primary connector.

## Syntax (C#)
```csharp
public void AssignAsPrimary()
```

## Remarks
This method is used to promote this connector as primary, and the rest of connectors in this system will be assigned as secondary.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when fail to assign this connector as primary.


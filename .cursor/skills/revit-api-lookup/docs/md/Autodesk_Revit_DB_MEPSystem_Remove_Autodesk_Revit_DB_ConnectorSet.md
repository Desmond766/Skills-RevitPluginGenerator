---
kind: method
id: M:Autodesk.Revit.DB.MEPSystem.Remove(Autodesk.Revit.DB.ConnectorSet)
zh: 删除、移除
source: html/59f27f95-ca35-d3e1-ccf4-5103133be3b1.htm
---
# Autodesk.Revit.DB.MEPSystem.Remove Method

**中文**: 删除、移除

Removes connectors from system.

## Syntax (C#)
```csharp
public void Remove(
	ConnectorSet connectors
)
```

## Parameters
- **connectors** (`Autodesk.Revit.DB.ConnectorSet`) - The connectors to be removed from the system.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown when the input argument elements is Nothing nullptr a null reference ( Nothing in Visual Basic) , or any element in that collection is Nothing nullptr a null reference ( Nothing in Visual Basic) .
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown when some of the connectors can't be removed, or when trying to remove all connectors from the system.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when the operation failed.


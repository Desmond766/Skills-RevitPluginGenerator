---
kind: method
id: M:Autodesk.Revit.DB.MEPSystem.Add(Autodesk.Revit.DB.ConnectorSet)
zh: 系统
source: html/f40dba23-b703-6a37-0e09-7dfcd2eb1955.htm
---
# Autodesk.Revit.DB.MEPSystem.Add Method

**中文**: 系统

Add elements into the system and connect them with the system using given connectors.

## Syntax (C#)
```csharp
public virtual void Add(
	ConnectorSet connectors
)
```

## Parameters
- **connectors** (`Autodesk.Revit.DB.ConnectorSet`) - Connectors which are used to connect with the system.

## Remarks
Note: this method may not be called during dynamic update.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown when the input argument connectors is Nothing nullptr a null reference ( Nothing in Visual Basic) , or any connector in that collection is Nothing nullptr a null reference ( Nothing in Visual Basic) .
- **Autodesk.Revit.Exceptions.ArgumentException** - Throw when any of the input connectors have been already used,
or when they don't share the same domain or system type as the system.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when the operation failed.
- **Autodesk.Revit.Exceptions.ForbiddenForDynamicUpdateException** - Thrown if this method is called during dynamic update.


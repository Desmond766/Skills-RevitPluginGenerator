---
kind: method
id: M:Autodesk.Revit.DB.Electrical.ElectricalSystem.Create(Autodesk.Revit.DB.Connector,Autodesk.Revit.DB.Electrical.ElectricalSystemType)
zh: 创建、新建、生成、建立、新增
source: html/bf9ecfac-db2f-385e-251d-eec44e791d87.htm
---
# Autodesk.Revit.DB.Electrical.ElectricalSystem.Create Method

**中文**: 创建、新建、生成、建立、新增

Creates a new MEP Electrical System element from an unused Connector.

## Syntax (C#)
```csharp
public static ElectricalSystem Create(
	Connector connector,
	ElectricalSystemType elecSysType
)
```

## Parameters
- **connector** (`Autodesk.Revit.DB.Connector`) - The Connector to create this Electrical System.
- **elecSysType** (`Autodesk.Revit.DB.Electrical.ElectricalSystemType`) - The System Type of electrical system.

## Returns
If successful a new MEP Electrical System element within the project, otherwise Nothing nullptr a null reference ( Nothing in Visual Basic) .

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration
- **Autodesk.Revit.Exceptions.DisabledDisciplineException** - None of the following disciplines is enabled: Mechanical Electrical Piping.


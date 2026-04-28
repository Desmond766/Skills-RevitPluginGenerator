---
kind: method
id: M:Autodesk.Revit.DB.Electrical.ElectricalSystem.Create(Autodesk.Revit.DB.Document,System.Collections.Generic.IList{Autodesk.Revit.DB.ElementId},Autodesk.Revit.DB.Electrical.ElectricalSystemType)
zh: 创建、新建、生成、建立、新增
source: html/66f12d78-a4ab-9b99-ef49-92c3a3e1835e.htm
---
# Autodesk.Revit.DB.Electrical.ElectricalSystem.Create Method

**中文**: 创建、新建、生成、建立、新增

Creates a new MEP Electrical System element from a set of electrical components.

## Syntax (C#)
```csharp
public static ElectricalSystem Create(
	Document document,
	IList<ElementId> electComponents,
	ElectricalSystemType elecSysType
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The Document.
- **electComponents** (`System.Collections.Generic.IList < ElementId >`) - The electrical components in this system.
- **elecSysType** (`Autodesk.Revit.DB.Electrical.ElectricalSystemType`) - The System Type of electrical system.

## Returns
If successful a new MEP Electrical System element within the project, otherwise Nothing nullptr a null reference ( Nothing in Visual Basic) .

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - There should be at least one component that can create the specified circuit type
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration
- **Autodesk.Revit.Exceptions.DisabledDisciplineException** - None of the following disciplines is enabled: Mechanical Electrical Piping.


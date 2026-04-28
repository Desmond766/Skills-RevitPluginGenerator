---
kind: method
id: M:Autodesk.Revit.DB.FabricationPartType.Create(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.FabricationServiceButton,System.Int32)
zh: 创建、新建、生成、建立、新增
source: html/b36e8a6b-8bf0-8332-e366-bc6da145adac.htm
---
# Autodesk.Revit.DB.FabricationPartType.Create Method

**中文**: 创建、新建、生成、建立、新增

Creates a fabrication part type element based on a specific fabrication servic button and condition.

## Syntax (C#)
```csharp
public static FabricationPartType Create(
	Document document,
	FabricationServiceButton button,
	int condition
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document.
- **button** (`Autodesk.Revit.DB.FabricationServiceButton`) - The fabrication service button.
- **condition** (`System.Int32`) - The condition index.

## Returns
The created fabrication part type element.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Fabrication service button contains invalid fittings.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - The index condition is not larger or equal to 0 and less than ConditionCount.
- **Autodesk.Revit.Exceptions.DisabledDisciplineException** - None of the following disciplines is enabled: Mechanical Electrical Piping.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The fabrication part type already exists.


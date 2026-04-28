---
kind: method
id: M:Autodesk.Revit.DB.Analysis.EnergyAnalysisDetailModel.Create(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.Analysis.EnergyAnalysisDetailModelOptions)
zh: 创建、新建、生成、建立、新增
source: html/70c30770-b4ea-53e0-3906-1d5a5061c478.htm
---
# Autodesk.Revit.DB.Analysis.EnergyAnalysisDetailModel.Create Method

**中文**: 创建、新建、生成、建立、新增

Creates a new energy analysis detailed model.

## Syntax (C#)
```csharp
public static EnergyAnalysisDetailModel Create(
	Document document,
	EnergyAnalysisDetailModelOptions options
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document that contains the physical model of the building.
- **options** (`Autodesk.Revit.DB.Analysis.EnergyAnalysisDetailModelOptions`) - The options to control the calculation rules.

## Returns
The created model instance.

## Remarks
The generated energy model is always returned in world coordinates.
 The method TransformModel() transforms all surfaces in the model according to
 ground plane, shared coordinates and true north.
 The EnergyModelType in argument EnergyAnalysisDetailModelOptions indicates
 whether the generated energy model is based on rooms/spaces or building elements. The default value
 is EnergyModelType.SpatialElement.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - An EnergyAnalysisDetailModel cannot be created if EnergyModelType.BuildingElement is input
 and AnalysisMode.ConceptualMasses is set in EnergyDataSettings (these values are incompatible).
 -or-
 Throws if there are no valid spatial bounding elements,
 or no valid spatial elements in the document.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Failed to create the energy analysis detail model.
- **Autodesk.Revit.Exceptions.OperationCanceledException** - Throws if user aborted the energy analysis detail model creation.


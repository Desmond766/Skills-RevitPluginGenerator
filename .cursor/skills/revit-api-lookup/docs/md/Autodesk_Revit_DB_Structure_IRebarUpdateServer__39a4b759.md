---
kind: type
id: T:Autodesk.Revit.DB.Structure.IRebarUpdateServer
source: html/3e845cad-eca0-ccb3-785b-48a32a9f2677.htm
---
# Autodesk.Revit.DB.Structure.IRebarUpdateServer

Represents an interface that should be overridden to allow the generation and update of free form rebar geometry.

## Syntax (C#)
```csharp
public interface IRebarUpdateServer : IExternalServer
```

## Remarks
This interface should be overridden in order to create a free form rebar with constraints and to allow generation and update of its geometry. 
 Once a rebar is created with a server, it will be called GetCustomHandles(RebarHandlesData) function. In the execution on this function should be defined the handles of the rebar.
 Based on these handles rebar constraints can be defined. Once the constraints are defined a regeneration should be triggered in order to generate the bar geometry. During the regeneration the functions GenerateCurves(RebarCurvesData) and TrimExtendCurves(RebarTrimExtendData) will be called.
 For GenerateCurves() it is supposed to calculate bars in set based on constraints.
 For TrimExtendCurves() it is supposed to trim or extend curves that were obtained from GenerateCurves(). Also in this function new constraints
 for start and end bar handles can be created.
 After the execution of these two functions the bar should appear on screen. Every time when a constraint is modified a new regeneration is triggered and the functions GenerateCurves() and TrimExtendCurves() are called again. We also can edit constraints for this rebar. When user starts to do this, the function GetHandlesPosition(RebarHandlePositionData) will be called
 and it is supposed to return positions of handles defined in GetCustomHandles(). This positions will be shown on screen.
 While editing constraints if the mouse is over a position that was specified, the function GetCustomHandleName(RebarHandleNameData) 
 will be called in order to obtain the name of that handle. While editing constraints an user will modify constraints (e.g. add a new reference or remove one) a regeneration will be triggered
 and the functions GenerateCurves() and TrimExtendCurves() will be called again.


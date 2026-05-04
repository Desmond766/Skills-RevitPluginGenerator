---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarShape.Create(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.Structure.RebarShapeDefinition,Autodesk.Revit.DB.Structure.RebarShapeMultiplanarDefinition,Autodesk.Revit.DB.Structure.RebarStyle,Autodesk.Revit.DB.Structure.StirrupTieAttachmentType,System.Int32,Autodesk.Revit.DB.Structure.RebarHookOrientation,System.Int32,Autodesk.Revit.DB.Structure.RebarHookOrientation,System.Int32)
zh: 创建、新建、生成、建立、新增
source: html/2dd89e4d-0953-8cf2-9441-10d07e6155fa.htm
---
# Autodesk.Revit.DB.Structure.RebarShape.Create Method

**中文**: 创建、新建、生成、建立、新增

Create a new instance of a Rebar Shape, which defines the shape of a rebar.

## Syntax (C#)
```csharp
public static RebarShape Create(
	Document doc,
	RebarShapeDefinition definition,
	RebarShapeMultiplanarDefinition multiplanarDefinition,
	RebarStyle style,
	StirrupTieAttachmentType attachmentType,
	int startHookAngle,
	RebarHookOrientation startHookOrientation,
	int endHookAngle,
	RebarHookOrientation endHookOrientation,
	int higherEnd
)
```

## Parameters
- **doc** (`Autodesk.Revit.DB.Document`) - A document to contain the RebarShape.
- **definition** (`Autodesk.Revit.DB.Structure.RebarShapeDefinition`) - The definition of the rebar shape, as a set of curves in a plane
 driven by parameters.
- **multiplanarDefinition** (`Autodesk.Revit.DB.Structure.RebarShapeMultiplanarDefinition`) - If not null, the created RebarShape will be a 3D shape. The shape
 is built out of the planar RebarShapeDefinition, with additional
 out-of-plane segments defined by the RebarShapeMultiplanarDefinition
 object. Not supported in conjunction with RebarShapeDefinitionByArc
 of type Spiral or LappedCircle.
- **style** (`Autodesk.Revit.DB.Structure.RebarStyle`) - Whether the shape is to be used as a standard bar or a stirrup/tie.
- **attachmentType** (`Autodesk.Revit.DB.Structure.StirrupTieAttachmentType`) - When the style is stirrup/tie, specify whether it will attach to the
 interior of cover (cover is measured to the stirrups), or to the
 exterior of cover (cover is measured to the standard bars).
 Ignored when the style is Standard.
- **startHookAngle** (`System.Int32`) - The start hook angle, expressed as an integral number of degrees.
 If 0, the shape will have no start hook. Common values are 0, 90, 135, and 180.
- **startHookOrientation** (`Autodesk.Revit.DB.Structure.RebarHookOrientation`) - The orientation of the start hook.
 Ignored when startHookAngle is 0.
- **endHookAngle** (`System.Int32`) - The end hook angle, expressed as an integral number of degrees.
 If 0, the shape will have no end hook. Common values are 0, 90, 135, and 180.
- **endHookOrientation** (`Autodesk.Revit.DB.Structure.RebarHookOrientation`) - The orientation of the end hook.
 Ignored when endHookAngle is 0.
- **higherEnd** (`System.Int32`) - When the rebar crosses itself, one end will be "lifted" to avoid self-intersection.
 Specify which end should be lifted: 0 for start, 1 for end.

## Returns
A new RebarShape instance.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - definition is linked to a Document other than doc.
 -or-
 A multiplanar definition is specified when the given RebarShapeDefinition
 does not support it. The following RebarShapeDefinitions do not support
 multiplanar: a simple line; spiral; lapped circle.
 -or-
 The DepthParamId property of multiplanarDefinition
 is invalid or has not been added to definition.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - startHookAngle must be at least 0 and no more than 180.
 -or-
 endHookAngle must be at least 0 and no more than 180.
 -or-
 higherEnd must be 0 or 1.
 -or-
 A value passed for an enumeration argument is not a member of that enumeration


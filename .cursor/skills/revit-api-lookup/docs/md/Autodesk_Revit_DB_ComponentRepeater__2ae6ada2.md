---
kind: type
id: T:Autodesk.Revit.DB.ComponentRepeater
source: html/27dbc5bd-40e7-c044-11e6-7053adf92c6f.htm
---
# Autodesk.Revit.DB.ComponentRepeater

An element that contains and manages a set of repeated components.

## Syntax (C#)
```csharp
public class ComponentRepeater : Element, 
	IEnumerable<ComponentRepeaterSlot>
```

## Remarks
Component repeaters can be used to replicate (repeat) elements hosted on repeating references.
 The result of the repeating operation is a collection of slots. Each slot contains one repeated component.
 The ComponentRepeater class provides the repeating functionality and access to the slots.
Each repeating reference is capable of hosting one point of an adaptive component. An initial pattern can be created
 by populating one or more repeating references with such points. Component repeaters can then be used
 to replicate the pattern to fill the rest of the repeating references in the particular repeating reference source.
The repeating references in repeating reference source are arranged in one or two dimensional arrays,
 allowing for different kinds of repeating:
 One dimensional source allows for repeating along a path. Two dimensional source allows for repeating across a grid. It is also possible to host a point on a zero dimensional reference (a point). This point will be shared by all slots.
 A zero dimensional source allows for repeating around a single point. It should not be used alone, but together
 with at least one other repeating reference source (typically one dimensional.) The point hosted on the zero dimensional
 source serves as a central point around which other points can be repeated on their respective repeating reference
 sources. 
 Multiple adaptive components may be hosted on one repeating reference source, and different points of one
 adaptive component may be hosted on different repeating reference sources, effectively allowing different points
 of an adaptive component to be repeated using different patterns.
Following is a typical component repeater creation workflow:
 Get the default repeating reference source from a point element, divided path or divided surface.
 (See HasRepeatingReferenceSource(Document, ElementId) 
 and GetDefaultRepeatingReferenceSource(Document, ElementId) .) Query the bounds of the repeating reference source to find a range of valid coordinates.
 (See DimensionCount 
 and GetBounds () () () .) Create one or more instances of adaptive families that will be repeated. Host the individual points of an adaptive component on one or more repeating references.
 (See GetReference(RepeaterCoordinates) .) Repeat the set of adaptive components using the RepeatElements() method. 
 Component repeaters can only be used in Massing families (the conceptual design environment).


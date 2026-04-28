---
kind: type
id: T:Autodesk.Revit.DB.RepeatingReferenceSource
source: html/c1a3887e-0272-7dcb-bed3-85c807ec39a0.htm
---
# Autodesk.Revit.DB.RepeatingReferenceSource

Represents a collection of repeating references.

## Syntax (C#)
```csharp
public class RepeatingReferenceSource : IDisposable
```

## Remarks
The RepeatingReferenceSource class is the building block for setting up component repeaters. Repeating references are arranged
 in zero, one or two dimensional arrays. The RepeatingReferenceSource class represents this array of references
 and provides access to individual repeating references.
Note that there may be gaps in the array (for example a repeating reference source formed by a divided surface with
 holes, or is non-rectangular surface.)
Repeating reference sources are a property of an element. Only point elements, divided paths and divided surface elements
 support repeating reference sources. These element respectively have 0, 1 and 2 dimensional repeating references.
 Use the HasRepeatingReferenceSource() method to query whether an element supports repeating reference sources and the
 GetDefaultRepeatingReferenceSource() method to obtain a repeating reference source from a given element.
See the ComponentRepeater and ComponentRepeaterSlot classes
 for more information.


---
kind: method
id: M:Autodesk.Revit.DB.NumberingSchema.AppendSequence(System.String,System.String)
source: html/0a89ca78-ca34-93fa-4fa7-71883a535497.htm
---
# Autodesk.Revit.DB.NumberingSchema.AppendSequence Method

Appends all elements of one numbering sequence to the end of another sequence.

## Syntax (C#)
```csharp
public void AppendSequence(
	string fromPartition,
	string toPartition
)
```

## Parameters
- **fromPartition** (`System.String`) - Name of the partition that determines which numbering sequence to append.
 The sequence must exist already, otherwise an exception will be thrown.
- **toPartition** (`System.String`) - Name of a partition into which the source sequence is going to be appended.
 The sequence must exist already, otherwise an exception will be thrown.

## Remarks
All numbers assigned to elements in the target sequence remain the same,
 but numbers in the source sequence (the one getting appended) will change.
 Elements that match elements in the target sequence will get the same
 numbers assigned. Remaining elements will get consecutive numbers in the
 creation order of the elements starting with the next highest
 number available in the target sequence. This operation modifies the Partition parameter of all elements
 in the sequence that is getting appended. Therefore, all its elements
 must be accessible for editing, otherwise this operation will fail. Elements can be appended only to a sequence that already exists. In order to
 reassign elements of one sequence to a partition that does not exist yet,
 use either the MoveSequence or
 MergeSequences methods.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The sequence fromPartition does not exist in the schema.
 -or-
 The sequence toPartition does not exist in the schema.
 -or-
 Given partition names fromPartition and toPartition must be different.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Either the schema or its document cannot be modified at present.
 -or-
 Thrown if there is an element that cannot have new value of the NUMBER_PARTITION_PARAM
 parameter assigned. It may be an indication that the element is not free to be edited at present.


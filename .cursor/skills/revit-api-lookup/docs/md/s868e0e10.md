---
kind: method
id: M:Autodesk.Revit.DB.NumberingSchema.MoveSequence(System.String,System.String)
source: html/9ae38f60-e76f-5bd7-1d71-bd57cf06f641.htm
---
# Autodesk.Revit.DB.NumberingSchema.MoveSequence Method

Moves all elements of a numbering sequence from one partition to another.

## Syntax (C#)
```csharp
public void MoveSequence(
	string fromPartition,
	string newPartition
)
```

## Parameters
- **fromPartition** (`System.String`) - Name of the partition that determines which numbering sequence to move.
 The sequence must exist already, otherwise an exception will be thrown.
- **newPartition** (`System.String`) - Name of a partition into which the source sequence is going to be moved.
 The schema must not have a sequence for this partition yet
 (i.e. the schema does not have an element that was assigned to such a partition.)
 Leading and trailing white space is ignored in the given string and will be
 removed automatically.

## Remarks
All numbers assigned to elements in the sequence remain the same. This operation modifies the Partition parameter of all elements
 in the given sequence. Therefore, all the elements must be accessible
 for editing. Elements can be moved only to a partition that does not exist yet. To move elements
 to an existing partition use the AppendSequence method.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The sequence fromPartition does not exist in the schema.
 -or-
 The sequence newPartition does already exist in the schema.
 -or-
 the given newPartition cannot be used as a valid name of a numbering partition
 because it contains characters that are considered invalid, such as
 non-printable characters or those that cannot be used in a file's name.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Either the schema or its document cannot be modified at present.
 -or-
 Thrown if there is an element that cannot have new value of the NUMBER_PARTITION_PARAM
 parameter assigned. It may be an indication that the element is not free to be edited at present.


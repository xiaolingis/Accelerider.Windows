﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Accelerider.Windows.Infrastructure.Interfaces
{
    public interface INetDiskUser
    {
        // User Information ---------------------------------------------------------------
        string Username { get; }

        DataSize TotalCapacity { get; }

        DataSize UsedCapacity { get; }

        Task<bool> RefreshUserInfoAsync();

        // Operates net-disk file ---------------------------------------------------------
        ITransferTaskToken UploadAsync(FileLocation from, FileLocation to);

        //Task<IReadOnlyCollection<ITransferTaskToken>> DownloadAsync(ILazyTreeNode<INetDiskFile> fileNode, FileLocation downloadFolder = null);

        Task DownloadAsync(ILazyTreeNode<INetDiskFile> fileNode, FileLocation downloadFolder, Action<ITransferTaskToken> action);// TODO: Changes it to IAsyncEnumerable<T> when the C# 8.0 is released.

        Task<(ShareStateCode, ISharedFile)> ShareAsync(IEnumerable<INetDiskFile> files, string password = null);

        // Gets net-disk files ------------------------------------------------------------
        Task<ILazyTreeNode<INetDiskFile>> GetNetDiskFileRootAsync();

        Task<IEnumerable<ISharedFile>> GetSharedFilesAsync();

        Task<IEnumerable<IDeletedFile>> GetDeletedFilesAsync();
    }
}

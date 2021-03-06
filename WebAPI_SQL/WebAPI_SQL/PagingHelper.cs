﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI_SQL
{
    public class PagingHelper
    {
        /// <summary>
        /// DataTable分页
        /// </summary>
        /// <param name="sourceDataTable"></param>
        /// <param name="PageIndex"></param>
        /// <param name="PageSize"></param>
        /// <returns></returns>
        public static DataTable GetPagedTable(DataTable sourceDataTable, int PageIndex, int PageSize)//PageIndex表示第几页，PageSize表示每页的记录数
        {
            DataTable result = new DataTable();
            if (sourceDataTable != null)
            {
                if (sourceDataTable.Rows.Count > 0)
                {
                    if (PageIndex > 0)
                    {
                        result = sourceDataTable.Copy();
                        result.Clear();//copy dt的结构

                        int rowbegin = (PageIndex - 1) * PageSize;
                        int rowend = PageIndex * PageSize;

                        if (rowbegin >= sourceDataTable.Rows.Count)
                        {
                            return result;//源数据记录数小于等于要显示的记录，直接返回dt
                        }

                        if (rowend > sourceDataTable.Rows.Count)
                        {
                            rowend = sourceDataTable.Rows.Count;
                        }

                        for (int i = rowbegin; i <= rowend - 1; i++)
                        {
                            DataRow newdr = result.NewRow();
                            DataRow dr = sourceDataTable.Rows[i];
                            foreach (DataColumn column in sourceDataTable.Columns)
                            {
                                newdr[column.ColumnName] = dr[column.ColumnName];
                            }
                            result.Rows.Add(newdr);
                        }
                    }
                    else
                    {
                        //PageIndex == 0页代表不分页数据，直接返回原始数据
                        result = sourceDataTable;
                    }
                }
                else
                {
                    //DataTable中无记录，直接返回原始数据
                    result = sourceDataTable;
                }
            }
            return result;
        }
    }
}

import React, { useEffect, useState } from 'react';
import { SiteIcon } from '../../assets';
import { Panel } from '../../global/components';
import { SITE_DESCRIPTION, SITE_TITLE } from '../../global/constants/strings';
import { ICategory } from '../../global/interfaces/category';
import { CategoryService } from '../../services';
import { BoardsOverviewPanel, Footer } from './components';
import './styles.scss';

const categoryService = new CategoryService()

const Home = () => {
    const [descriptionDismissed, setDescriptionDismissed] = useState<boolean>(false)
    const [categories, setCategories] = useState<ICategory[]>([])

    useEffect(() => {
        let mounted = true

        categoryService.getAll().then(c => {
            if (mounted) {
                setCategories(c)
            }
        })

        return () => {
            mounted = false
        }
    }, [])

    return (
        <div className="home-panel">
            <SiteIcon onClick={() => window.location.reload()} />
            {!descriptionDismissed &&
                <Panel dismissable title={SITE_TITLE} onClose={() => setDescriptionDismissed(true)}>
                    <span>{SITE_DESCRIPTION}</span>
                </Panel>
            }
            <BoardsOverviewPanel categories={categories} />
            <Footer />
        </div>)
}

export default Home
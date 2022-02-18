import React, { useEffect, useState } from 'react';
import { SiteIcon } from '../../assets';
import { Panel } from '../../global/components';
import { SITE_DESCRIPTION, SITE_TITLE } from '../../global/constants/strings';
import { ICategory } from '../../global/interfaces/category';
import { CategoryService } from '../../services';
import { Footer } from './components';
import BoardCategory from './components/boardCategory/boardCategory';
import './styles.scss';

const _categoryService = new CategoryService()

const Home = () => {
    const [descriptionDismissed, setDescriptionDismissed] = useState<boolean>(false)
    const [categories, setCategories] = useState<ICategory[]>([])

    useEffect(() => {
        let mounted = true

        _categoryService.getAll().then(c => {
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
            <Panel title="Boards">
                {categories.map(category => {
                    return (
                        <BoardCategory
                            key={category.id}
                            category={category.name}
                            boards={category.boards}
                        />)
                })}
            </Panel>
            <Footer />
        </div>)
}

export default Home